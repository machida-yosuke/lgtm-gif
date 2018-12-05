import * as firebase from 'firebase/app';
import 'firebase/database';
import 'firebase/storage';
import EventEmitter from 'events';
import config from './firebaseConfig';
import { FIREBASE_PATH } from './config';

firebase.initializeApp(config);
const db = firebase.database();
const dbDatas = db.ref(`${FIREBASE_PATH.ROOT_PATH}${FIREBASE_PATH.DATAS_PATH}`);
const storageRef = firebase.storage().ref();

class FireBaseManager extends EventEmitter {
  constructor() {
    super();
    this.isPostGif = false;
  }

  getGif() {
    this.onEmitGetData = snapshot => {
      this.emit('emitGetData', snapshot.val());
    };

    dbDatas
      .orderByKey()
      .limitToLast(30)
      .once('value', this.onEmitGetData);
  }

  async postGif(src) {
    if (this.isPostGif) return;
    this.isPostGif = true;
    const uploadRef = await storageRef.child(`${src.name}.gif`);
    const snapshot = await uploadRef.put(src.blob);
    console.log(snapshot, 'snapshot');
    const url = await uploadRef.getDownloadURL();
    const createdTime = firebase.database.ServerValue.TIMESTAMP;
    const dbpush = dbDatas.push();
    dbpush.set({
      uid: dbpush.key,
      url,
      effect: src.effect,
      timestamp: createdTime,
    });
    this.isPostGif = false;
    this.emit('postComp');
  }
}

const firebaseManager = new FireBaseManager();
export default firebaseManager;
