<template lang="pug">
  .camera
    video.camera-video(ref='video' autoplay playsinline="true")
    canvas.camera-canvas(ref='cameraCanvas')
    .effect-list-wrap(v-if='isWebglInit')
      EffectList
    Navi(v-if='ua.isSP' @capture='capture' :isCapture='isCapture' :count='captureCount')
    Modal(v-if='isShowModal && verifier' :text='modalText' :gif='gif' :sitepolicyText ='"※Aboutページからサイトポリシーをご確認ください"' :type='modalType' @close='closeModal' @postGif='postGif')
    Modal(v-if='isShowModal && !verifier' :text='"GIF長押しで保存できます"' :type="'notVerifier'" :gif='gif' @close='closeModal')
    Modal(v-if='!checkUserMedia' :text='"お使いのブラウザまたは、端末は対応していません。"' :type='modalType' :gif="'./img/notUserMedia.gif'" @goGallery='goGallery')
</template>
<script>
import WebglCamera from '@/assets/js/WebglCamera';
import EffectList from '@/components/EffectList';
import getUserMedia from '@/assets/js/getUserMedia';
import Navi from '@/components/Navi';
import Modal from '@/components/Modal';
import { mapActions, mapState } from 'vuex';
import { framerate, timeLimit, EFFECTS_LIST } from '@/assets/js/config';
import firebaseManager from '@/assets/js/FirebaseManager';

export default {
  name: 'camera',
  components: {
    Navi,
    EffectList,
    Modal,
  },
  data() {
    return {
      modalType: '',
      captureCount: 0,
      blobGif: null,
      gif: null,
      isCapture: false,
      isShowModal: false,
      isCameraSet: false,
      modalText: 'このGIFをアップロードしますか？',
      checkUserMedia: true,
      isWebglInit: false,
    };
  },
  created() {
    if (this.ua.isPC) {
      this.$router.push({ path: '/' });
    }

    this.goCamera();
  },
  async mounted() {
    if (this.ua.isPC) return;
    this.webglCamera = new WebglCamera();
    this.checkUserMedia = await getUserMedia(this.$refs.video);
    this.modalType = this.checkUserMedia ? 'correspond' : 'notCorrespond';
    this.$refs.video.addEventListener('playing', () => {
      this.isWebglInit = true;
      this.isCameraSet = true;
      this.webglCamera.setDom(this.$refs.cameraCanvas, this.$refs.video);
    });

    this.captureComp = () => {
      this.isCapture = false;
      this.isShowModal = true;
    };

    this.saveComp = (blob) => {
      this.blobGif = blob;
      this.gif = URL.createObjectURL(blob);
    };

    this.decrementCount = (count) => {
      this.captureCount = framerate * timeLimit - count;
    };

    this.postComp = () => {
      this.modalType = 'postComp';
      this.modalText = 'GIFのアップロードが完了しました。';
    };

    this.webglCamera.on('captureComp', this.captureComp);
    this.webglCamera.on('saveComp', this.saveComp);
    this.webglCamera.on('decrementCount', this.decrementCount);
    firebaseManager.on('postComp', this.postComp);
  },
  destroyed() {
    if (!this.webglCamera) return;
    this.webglCamera.removeListener('captureComp', this.captureComp);
    this.webglCamera.removeListener('saveComp', this.saveComp);
    this.webglCamera.removeListener('decrementCount', this.decrementCount);
    firebaseManager.removeListener('postComp', this.postComp);
    this.webglCamera.destroy();
  },
  methods: {
    ...mapActions([
      'goCamera',
      'startCapture',
    ]),
    closeModal() {
      this.isCapture = false;
      this.gif = null;
      this.isShowModal = false;
      this.modalText = 'このGIFをアップロードしますか？';
      this.modalType = this.checkUserMedia ? 'correspond' : 'notCorrespond';
    },
    capture() {
      if (!this.isCameraSet || this.isCapture) return;
      this.isCapture = true;
      this.startCapture();
      this.webglCamera.startCapture();
    },
    crateRandomName() {
      const l = 10;
      const c = 'abcdefghijklmnopqrstuvwxyz0123456789';
      const cl = c.length;
      let r = '';
      for (let i = 0; i < l; i += 1) {
        r += c[Math.floor(Math.random() * cl)];
      }
      return r;
    },
    postGif() {
      this.modalType = 'postNow';
      this.modalText = 'GIFをアップロード中・・・';
      const src = {
        blob: this.blobGif,
        name: this.crateRandomName(),
        effect: EFFECTS_LIST[this.effectNum],
      };
      firebaseManager.postGif(src);
    },
    goGallery() {
      this.$router.push({ path: '/' });
    },
  },
  computed: {
    ...mapState([
      'effectNum',
      'ua',
    ]),
    verifier() {
      return this.$route.query.kayac ? 1 : 0;
    },
  },
  watch: {
    effectNum(num) {
      if (this.webglCamera) {
        this.webglCamera.setEffect(num);
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.camera {
  position: absolute;
  top: 0;
  left: 0;
  width: 750px;
  height: 100%;
  overflow: hidden;
  background: $black;
}
.camera-video {
  width: 1px;
  height: 1px;
  top: 0;
  left: 0;
  pointer-events: none;
}
.camera-canvas {
  position: relative;
  top: 0px;
  left: 0;
  margin: 0 auto;
  background: $black;
  pointer-events: none;
  transform-origin: top;
  transform: scale(1.5625 * 2);
}

.effect-list-wrap {
  animation: fade-in 1500ms both $good-easing-2;
}
</style>
