<template lang="pug">
.gallery(:data-pc='ua.isPC ? 1 : 0')
  .gif-wrap
    .gif(v-for="gif,index in gifData" @click='openModal')
      img.gif__image(v-lazy="gif.url" :data-num='index')
  Navi(v-if='ua.isSP')
  Modal(v-if='isShowModal' :gifInfo='gifInfo' :type="'gallery'" :gif='gif' @close='closeModal')
</template>

<script>
import Navi from '@/components/Navi';
import { mapActions, mapState } from 'vuex';
import firebaseManager from '@/assets/js/FirebaseManager';
import _ from 'lodash';
import Modal from '@/components/Modal';

export default {
  name: 'gallery',
  components: {
    Navi,
    Modal,
  },
  data() {
    return {
      isShowModal: false,
      gif: null,
      gifInfo: null,
    };
  },
  created() {
    this.goGallery();
    if (this.gifData) return;
    this.getData = (data) => {
      const reverseDatas = _.reverse(_.values(data));
      this.getGifData(reverseDatas);
    };
    firebaseManager.getGif();
    firebaseManager.on('emitGetData', this.getData);
  },
  destroyed() {
    if (this.gifData) return;
    firebaseManager.removeListener('emitGetData', this.getData);
  },
  computed: {

    ...mapState([
      'gifData',
      'ua',
    ]),
  },
  methods: {
    ...mapActions([
      'goGallery',
      'getGifData',
    ]),
    openModal(e) {
      const num = e.target.getAttribute('data-num');
      this.gif = this.gifData[num].url;
      this.gifInfo = this.gifData[num];
      this.isShowModal = true;
    },
    closeModal() {
      this.isShowModal = false;
    },
  },
};
</script>

<style lang="scss" scoped>
.gallery {
  &[data-pc="1"] {
    background: $white;
    .gif-wrap {
      max-width: 1200px;
      width: 80%;
      padding: 90px 0 60px;
      margin: 0 auto;
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(180px, 1fr));
      grid-auto-rows: 1fr;
      grid-column-gap: 3px;
    }
    .gif {
      &__image {
        width: 100%;
        height: 100%;
        border-radius: 20px;
      }
    }
  }
  &[data-pc="0"] {
    position: absolute;
    width: 100%;
    margin: 0 auto;
    height: 100%;
    overflow: hidden;
    background: $white;
    .gif-wrap {
      width: 369px * 2;
      margin: 6px auto 0;
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(240px, 1fr));
      grid-auto-rows: 320px;
      grid-column-gap: 6px;
      grid-row-gap: 6px;
      height: calc(100% - 86px);
      overflow-y: auto;
      overflow-x: hidden;
      -webkit-overflow-scrolling: touch;
    }
    .gif {
      &__image {
        width: 100%;
        height: 100%;
        border-radius: 20px;
      }
    }
  }
}
</style>
