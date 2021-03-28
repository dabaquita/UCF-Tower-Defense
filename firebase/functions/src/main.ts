import * as admin from 'firebase-admin'

admin.initializeApp()
const db = admin.firestore()

//Prevents 'undefined' value error when writing to Firestore
db.settings({ ignoreUndefinedProperties: true })

export {
    db,
    admin
}