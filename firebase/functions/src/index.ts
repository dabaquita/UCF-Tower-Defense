import * as functions from 'firebase-functions';
import { HttpsError } from 'firebase-functions/lib/providers/https';
import { db, admin } from './main'
import { FireKey } from './constants'
import * as Helper from './helpers'
import { User } from './user'
import { calculateLevel } from './levelCalcuation'

//This file is only for exporting cloud functions,
// put all other functionality in another file


//MARK: Create User

export const createUser = functions.https.onCall((data, context) => {

    const username: string = Helper.validateString(data.username)
    const email: string = Helper.validateString(data.email)
    const password: string = Helper.validateString(data.password)

    if (!Helper.isValidUsername(username)) {
        throw new HttpsError('aborted', 'User name must be an alphanumeric string between 6 and 15 characters.')
    }

    return admin.auth().createUser({
        uid: username,
        displayName: username,
        email: email,
        password: password
    }).then(async result => {
        const userInfo: User = {
            username: username,
            currentLevel: 0,
            xp: 0,
            highestWave: 0,
            unlockedMaps: {}
        }

        const mapNames = await Helper.getMapNames()
        mapNames.forEach(name => {
            userInfo.unlockedMaps[name] = false
        })

        return db.collection(FireKey.users).doc(username).set(userInfo)
    })

})


//MARK: Set Highest Wave

export const setHighestWave = functions.https.onCall((data, context) => {

    const uid = context.auth?.uid
    if (uid === undefined) {
        throw new HttpsError('unauthenticated', 'Not authenticated')
    }

    const newHighestWave = Helper.validateNumber(data.highestWave)

    return db.collection(FireKey.users).doc(uid).update({
        'highestWave': newHighestWave
    }).then(() => {
        return Helper.getUser(uid)
    })
})


//MARK: Unlock Map

export const unlockMap = functions.https.onCall((data, context) => {

    const uid = context.auth?.uid
    if (uid === undefined) {
        throw new HttpsError('unauthenticated', 'Not authenticated')
    }

    const mapName = Helper.validateString(data.mapName)

    const mapData: Record<string, boolean> = {}
    mapData[`unlockedMaps.${mapName}`] = true

    return db
        .collection(FireKey.users)
        .doc(uid)
        .update(mapData)
        .then(() => {
            return Helper.getUser(uid)
        })

})


//MARK: Add XP

export const addExperience = functions.https.onCall((data, context) => {

    const uid = context.auth?.uid

    if (uid === undefined) {
        throw new HttpsError('unauthenticated', 'Not authenticated')
    }

    const xp = Helper.validateNumber(data.xp)

    const userRef = db.collection(FireKey.users).doc(uid)

    console.log("Ok")

    //We need to use a transaction in case this method spammed.
    return db.runTransaction(async transaction => {
        return transaction.get(userRef).then(doc => {
            if (!doc.exists) {
                console.log('BAD')
                throw new HttpsError('internal', `User not found.`) //Should never occur since the user account is calling this method.
            } else {
                console.log('Good')
                return doc.data() as User
            }
        }).then(async user => {
            user.xp += xp
            user.currentLevel = calculateLevel(user.xp)
            console.log("Then")

            transaction.update(
                userRef,
                user
            )

            //Return the user out of the transaction back to the client.
            return user
        })
    })


})


export const getUserData = functions.https.onCall((data, context) => {

    const uid = context.auth?.uid
    if (uid === undefined) {
        throw new HttpsError('unauthenticated', 'Not authenticated')
    }

    return Helper.getUser(uid)
})
