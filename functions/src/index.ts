import * as functions from 'firebase-functions';
import { HttpsError } from 'firebase-functions/lib/providers/https';
import * as admin from 'firebase-admin'

admin.initializeApp()
const db = admin.firestore()

//Prevents 'undefined' value error when writing to Firestore
db.settings({ ignoreUndefinedProperties: true })

interface User {
    username: string
    currentLevel: number
    xp: number
    highestWave: number
    unlockedMaps: Record<string, boolean>
}


//Helper for validating outside data within a cloud function.
function validateString(value: any): string {
    if (typeof value !== 'string') {
        throw new HttpsError('invalid-argument', `Validation failed: ${typeof value} is not a string.`)
    } else {
        return value
    }
}

//Helper for validating outside data within a cloud function.
function validateNumber(value: any): number {
    if (typeof value !== 'number') {
        throw new HttpsError('invalid-argument', `Validation failed: ${typeof value} is not a number.`)
    } else {
        return value
    }
}


export const FireKey = {
    users: 'Users',
    meta: 'Meta'
}


function getMapNames(): Promise<string[]> {
    return db.collection(FireKey.meta).doc('Maps').get().then(doc => {
        if (doc.exists) {
            return doc.data()!.names as string[]
        } else {
            return []
        }
    }).catch(() => {
        return []
    })
}

function isValidUsername(str: string): boolean {
    const r = new RegExp('(([A-z]|[0-9]){6,15})')
    return str.match(r) !== null
}


export const createUser = functions.https.onCall((data, context) => {

    const username: string = validateString(data.username)
    const email: string = validateString(data.email)
    const password: string = validateString(data.password)

    if (!isValidUsername(username)) {
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

        const mapNames = await getMapNames()
        mapNames.forEach(name => {
            userInfo.unlockedMaps[name] = false
        })

        return db.collection(FireKey.users).doc(username).set(userInfo)
    })

})

export const setHighestWave = functions.https.onCall((data, context) => {

    const uid = context.auth?.uid
    if (uid === undefined) {
        throw new HttpsError('unauthenticated', 'Not authenticated')
    }

    const newHighestWave = validateNumber(data.highestWave)

    return db.collection(FireKey.users).doc(uid).update({
        'highestWave': newHighestWave
    }).then(() => {
        return null
    })
})


export const unlockMap = functions.https.onCall((data, context) => {

    const uid = context.auth?.uid
    if (uid === undefined) {
        throw new HttpsError('unauthenticated', 'Not authenticated')
    }

    const mapName = validateString(data.mapName)

    const mapData: Record<string, boolean> = {}
    mapData[`unlockedMaps.${mapName}`] = true

    return db.collection(FireKey.users).doc(uid).update(mapData)
        .then(() => {
            return null
        })

})