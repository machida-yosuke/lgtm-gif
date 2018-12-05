<template lang="pug">
.modal(:data-pc='ua.isPC? 1 : 0')
  .modal-bg.modal-bg--black(v-if='type==="gallery"' @click='close')
  .modal-bg(v-else)
  .modal-wrap

    .modal-img
      .modal-img__gif(
        :style="{ backgroundImage: 'url(' + gif + ')' }")
      img.modal-img__gif-download(:src='gif')
    .close-btn(v-if='type==="gallery"' @click='close')
      .close-btn__bar-1
      .close-btn__bar-2

    .modal-desc(v-if='type==="correspond" || type==="postNow" || type==="postComp"')
      .modal-desc__text(:data-correspond='type==="correspond"? 1 : 0') {{text}}
      .modal-desc__sitepolicy(v-if='type==="correspond"') {{sitepolicyText}}
      .modal-desc__btn
        Btn(:text='"Close"' :type='"ng"' @click.native='close' v-if='type==="postComp"')
        Btn(:text='"Retake"' :type='"ng"' @click.native='close' v-if='type==="correspond"')
        Btn(:text='"OK"' :type='"success"' @click.native='postGif' v-if='type==="correspond"')

    .modal-desc(v-if='type==="notVerifier"')
      .modal-desc__text {{text}}
      .modal-desc__btn
        Btn(:text='"Retake"' :type='"ng"' @click.native='close')

    .modal-desc(v-if='type==="gallery"')
      .modal-desc__info
        .modal-desc__info-time
          span.info-title Timestamp :
          span {{unixTime2ymd(gifInfo.timestamp)}}
        .modal-desc__info-effect
          span.info-title Effects :
          span {{gifInfo.effect}}
        .modal-desc__info-url
          span.info-title URL :
          a(:href='gifInfo.url' target='_blank') {{gifInfo.url}}

    .modal-desc(v-if='type==="notCorrespond"')
      .modal-desc__text {{text}}
      .modal-desc__btn
        Btn(:text='"Galleryへ"' :type='"ng"' @click.native='goGallery')
</template>
<script>
import Btn from '@/components/Btn';
import { mapState } from 'vuex';

export default {
  name: 'modal',
  props: ['gif', 'text', 'sitepolicyText', 'btn', 'type', 'gifInfo'],
  components: {
    Btn,
  },
  data() {
    return {
    };
  },
  computed: {
    ...mapState(['ua']),
  },
  methods: {
    close() {
      this.$emit('close');
    },
    goGallery() {
      this.$emit('goGallery');
    },
    postGif() {
      this.$emit('postGif');
    },
    unixTime2ymd(time) {
      const d = new Date(time);
      const month = d.getMonth() + 1;
      const day = d.getDate();
      const hour = (`0${d.getHours()}`).slice(-2);
      const min = (`0${d.getMinutes()}`).slice(-2);
      const sec = (`0${d.getSeconds()}`).slice(-2);
      return (`${month}-${day} ${hour}:${min}:${sec}`);
    },
  },
};
</script>

<style lang="scss" scoped>
.modal {
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  position: absolute;
  top: 0;
}

.modal-bg {
  background: rgba(0, 0, 0, 0.8);
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  animation: fade-in 200ms both $good-easing-2;
}

.modal {
  &[data-pc="1"] {
    .modal-wrap {
      width: 800px;
      height: 450px;
      background: #fff;
      border-radius: 20px;
      border: solid 1px $gray;
      box-sizing: border-box;
      animation: fade-in-scale 300ms both $good-easing-2;
    }
    .modal-img {
      height: 320px;
      width: 240px;
      margin-top: 65px;
      display: inline-block;
      animation: fade-in-up 300ms both $good-easing-2;
      animation-delay: 350ms;
      &__gif-download {
        opacity: 0;
        height: 100%;
        width: 100%;
        position: absolute;
      }
      &__gif {
        height: 100%;
        width: 100%;
      }
    }
    .modal-desc {
      display: inline-block;
      width: 50%;
    }
    .modal-desc__info {
      margin-left: 50px;
      text-align: left;
      color: $gray;
      font-size: 13px;
      &-time {
        animation: fade-in-right 300ms both $good-easing-2;
        animation-delay: 450ms;
      }
      &-effect {
        margin: 15px 0;
        animation: fade-in-right 300ms both $good-easing-2;
        animation-delay: 500ms;
      }
      &-url {
        word-break: break-all;
        line-height: 16px;
        animation: fade-in-right 300ms both $good-easing-2;
        animation-delay: 550ms;
        a {
          text-decoration: none;
          color: $gray;
        }
      }
    }
    .info-title {
      margin-right: 10px;
    }
  }
  &[data-pc="0"] {
    .modal-wrap {
      width: 80%;
      background: #fff;
      border-radius: 20px;
      border: solid 1px $gray;
      box-sizing: border-box;
      animation: fade-in-scale 300ms both $good-easing-2;
    }
    .modal-img {
      overflow: hidden;
      background-image: url("/img/create-gif.gif");
      background-repeat: no-repeat;
      background-size: cover;
      border-radius: 20px 20px 0 0;
      position: relative;
      &__gif-download {
        opacity: 0;
        width: 100%;
        height: 100%;
        position: absolute;
        top: 0;
        left: 0;
      }
      &__gif {
        background-repeat: no-repeat;
        background-size: cover;
        padding-bottom: (320 / 240) * 100%;
      }
      &__load {
        width: 100%;
        height: auto;
      }
    }
    .modal-desc {
      width: 100%;
      height: 230px;
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      &__text {
        font-size: $sentenceFontSize;
        color: $gray;
        font-weight: bold;
        text-align: center;
        margin-bottom: 30px;
        &[data-correspond="1"] {
          margin-bottom: 10px;
        }
        &[data-correspond="0"] {
          margin-bottom: 30px;
        }
      }
      &__sitepolicy {
        color: red;
        margin-bottom: 20px;
      }
      &__btn {
        display: flex;
        width: 70%;
        justify-content: space-around;
        margin: 0 auto;
      }
    }

    .modal-desc__info {
      text-align: left;
      margin: 5% auto;
      color: $gray;
      width: 80%;
      font-size: $sentenceFontSize;
      &-time {
        animation: fade-in-up 300ms both $good-easing-2;
        animation-delay: 450ms;
      }
      &-effect {
        margin: 15px 0;
        animation: fade-in-up 300ms both $good-easing-2;
        animation-delay: 500ms;
      }
      &-url {
        word-break: break-all;
        animation: fade-in-up 300ms both $good-easing-2;
        animation-delay: 550ms;
        a {
          text-decoration: none;
          color: $gray;
        }
      }
    }
    .info-title {
      margin-right: 10px;
    }
  }
}

.close-btn {
  width: 60px;
  height: 60px;
  top: 5px;
  right: 5px;
  position: absolute;
  &__bar-1 {
    width: 3px;
    height: 60px;
    background: $gray;
    transform: rotateZ(45deg);
    position: absolute;
    top: 0;
    left: 30px;
  }
  &__bar-2 {
    width: 3px;
    height: 60px;
    background: $gray;
    transform: rotateZ(-45deg);
    position: absolute;
    top: 0;
    left: 30px;
  }
}
</style>
