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
}


//Helper for validating outside data within a cloud function.
function validateString(value: any): string {
    if (typeof value !== 'string') {
        throw new HttpsError('invalid-argument', `Validation failed: ${typeof value} is not a string.`)
    } else {
        return value
    }
}


export const FireKey = {
    users: 'Users',
    maps: 'Maps',
    mapInfo: 'MapInfo'
}


export const createUser = functions.https.onCall((data, context) => {

    const username: string = validateString(data.username)
    const email: string = validateString(data.email)
    const password: string = validateString(data.password)

    //TODO: validate username with a regex

    return admin.auth().createUser({
        uid: username,
        displayName: username,
        email: email,
        password: password
    }).then(result => {
        const userInfo: User = {
            username: username,
            currentLevel: 0,
            xp: 0
        }
        return db.collection(FireKey.users).doc(username).set({ userInfo })
    })

})