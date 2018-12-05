<template lang="pug">
.modal
  .modal-bg.modal-bg--black(@click='close')
  .modal-about
    .modal-about__title About App
    .close-btn(@click='close')
      .close-btn__bar-1
      .close-btn__bar-2
    .modal-about-img
      .modal-about-img__lgtm
      .modal-about-img__kayac
    .modal-about-info
      .modal-about-info__intro あなただけのオリジナルLGTM(Looks Good To Me) GIF動画を作ろう！専用のWebアプリからカメラで撮影するとGIF動画が生成され、デジタルサイネージにそのまま反映されます！用意されたカメラフィルターを使えば、よりクリエイティブなLGTM GIF動画が作れるかも？
      .modal-about-info__staffs STAFF
        a.about__staff(href='https://www.kayac.com/team/machida-yosuke' target='_blank') Director : Machida Yosuke
        a.about__staff(href='https://www.kayac.com/team/machida-yosuke' target='_blank') Designer : Machida Yosuke
        a.about__staff(href='https://www.kayac.com/team/machida-yosuke' target='_blank') Frontend : Machida Yosuke
        a.about__staff(href='https://www.kayac.com/team/irie-shinnosuke' target='_blank') Frontend : Irie Shinnosuke
        a.about__staff(href='https://www.kayac.com/team/tagami-mio' target='_blank') Frontend : Tagami Mio
        a.about__staff(href='https://www.kayac.com/team/himeno-yusuke' target='_blank') Frontend : Himeno usuke
        a.about__staff(href='https://www.kayac.com/' target='_blank') Frontend : Suzuki Ryota
        a.about__staff(href='https://www.kayac.com/team/fujisawa-shin' target='_blank') Support : Fujisawa Shin
</template>
<script>

export default {
  name: 'pcAboutModal',
  data() {
    return {
    };
  },
  methods: {
    close() {
      this.$emit('close');
    },
  },
};
</script>

<style lang="scss" scoped>
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
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

.modal-about {
  border: solid 1px $gray;
  animation: fade-in-scale 300ms both $good-easing-2;
  width: 800px;
  display: flex;
  flex-direction: column;
  background: #fff;
  border-radius: 20px;
  border: solid 1px $gray;
  box-sizing: border-box;
  padding: 50px 0;
  &__title {
    font-size: 38px;
    text-align: center;
    font-weight: bold;
    color: $gray;
    animation: fade-in-up 300ms both $good-easing-2;
    animation-delay: 250ms;
  }
}

.modal-about-img {
  display: flex;
  margin: 32px auto;
  width: 250px;
  justify-content: space-between;
  align-items: flex-end;
  animation: fade-in-up 300ms both $good-easing-2;
  animation-delay: 300ms;
  &__kayac {
    @include set-image("common/kayac-logo.svg", 70px, 70px);
  }
  &__lgtm {
    @include set-image("common/lgtm-logo.png", 110px, 77px);
  }
}

.modal-about-info {
  display: flex;
  margin: 0 auto;
  width: 525px;
  justify-content: space-between;
  animation: fade-in-up 300ms both $good-easing-2;
  animation-delay: 350ms;
  &__intro {
    text-align: left;
    line-height: 23px;
    font-size: 13px;
    color: $gray;
    width: 280px;
  }
  &__staffs {
    text-align: left;
    font-size: 16px;
    color: $gray;
    width: 200px;
  }
}

.about__staff {
  display: block;
  margin-top: 13px;
  font-size: 13px;
  color: $gray;
}

.close-btn {
  width: 60px;
  height: 60px;
  top: 5px;
  right: 5px;
  position: absolute;
  &__bar-1 {
    width: 1px;
    height: 60px;
    background: $gray;
    transform: rotateZ(45deg);
    position: absolute;
    top: 0;
    left: 30px;
  }
  &__bar-2 {
    width: 1px;
    height: 60px;
    background: $gray;
    transform: rotateZ(-45deg);
    position: absolute;
    top: 0;
    left: 30px;
  }
}
</style>
