import { HttpsError } from 'firebase-functions/lib/providers/https'
import { db } from './main'
import { FireKey } from './constants'
import { User } from './user'


//Helper for validating outside data within a cloud function.
export function validateString(value: any): string {
    if (typeof value !== 'string') {
        throw new HttpsError('invalid-argument', `Validation failed: ${typeof value} is not a string.`)
    } else {
        return value
    }
}


//Helper for validating outside data within a cloud function.
export function validateNumber(value: any): number {
    if (typeof value !== 'number') {
        throw new HttpsError('invalid-argument', `Validation failed: ${typeof value} is not a number.`)
    } else {
        return value
    }
}


export function isValidUsername(str: string): boolean {
    const r = new RegExp('(([A-z]|[0-9]){6,15})')
    return str.match(r) !== null
}


export function getMapNames(): Promise<string[]> {
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


export async function getUser(uid: string): Promise<User> {
    return db.collection(FireKey.users).doc(uid).get()
        .then(doc => {
            if (doc.exists) {
                return doc.data() as User
            } else {
                throw new HttpsError('not-found', `Couldn't find user with id: ${uid}.`)
            }
        })
}