<template lang="pug">
.navi
  .navi-list
    .navi-list__item(data-name='gallery' :data-active='isShow("gallery") ? 1:0')
      router-link(to="/")
        .navi-gallery
        .navi-title Gallery
    .navi-list__item(data-name='camera' :data-active='isShow("camera") ? 1:0' :data-rec='0' @click='capture')
      .navi-camera(:data-capture='isCapture? 1 : 0')
        .navi-camera-count(v-if='isCapture') {{count}}
      .navi-title Camera
    .navi-list__item(data-name='about' :data-active='isShow("about") ? 1:0')
      router-link(to="/about")
        .navi-about
        .navi-title About
</template>
<script>
import { mapState } from 'vuex';

export default {
  name: 'navi',
  props: ['isCapture', 'count'],
  data() {
    return {};
  },
  computed: {
    ...mapState([
      'currentPage',
    ]),
  },
  methods: {
    capture() {
      if (this.currentPage === 'camera') {
        this.$emit('capture');
        return;
      }
      this.$router.push({ path: '/camera' });
    },
    isShow(page) {
      return this.currentPage === page;
    },
  },
};
</script>
<style lang="scss" scoped>
.navi {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 750px;
  height: 84px;
  background: $white;
  &-list {
    border-top: $gray solid 2px;
    margin: 0 auto;
    height: 84px;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
  }
}
.navi-list__item {
  width: 54px;
  &[data-name="camera"] {
    margin: 0 106px;
  }
}

.navi-title {
  margin-top: 5px;
  font-size: $naviFontSize;
  color: $gray;
}

.navi-list__item[data-active="0"] {
  .navi-title {
    color: $gray;
  }
  .navi-gallery {
    @include set-image("navi/gallery_off.svg", 32px, 45px);
    margin: 0 auto;
  }
  .navi-camera {
    @include set-image("navi/camera_off.svg", 54px, 45px);
    margin: 0 auto;
  }
  .navi-about {
    @include set-image("navi/about_off.svg", 34px, 46px);
    margin: 0 auto;
  }
}

.navi-list__item[data-active="1"] {
  .navi-title {
    color: $blue;
  }
  .navi-gallery {
    @include set-image("navi/gallery_on.svg", 32px, 45px);
    margin: 0 auto;
  }
  .navi-about {
    @include set-image("navi/about_on.svg", 34px, 46px);
    margin: 0 auto;
  }
}
.navi-list__item[data-active="1"][data-name="camera"] {
  width: 112px;
  height: 112px;
  margin-bottom: 100px;
  &::before {
    content: "";
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
    top: -84px;
    @include set-image("navi/navi-camera-on.svg", 190px, 95px);
  }
  .navi-camera {
    background: $red;
    border: solid 4px $black;
    box-sizing: border-box;
    position: absolute;
    &[data-capture="0"] {
      width: 112px;
      height: 112px;
      border-radius: 50%;
    }
    &[data-capture="1"] {
      width: 112px;
      height: 112px;
      transform: scale(0.8);
      transform-origin: 0.5;
      border-radius: 16px;
      transition: all 200ms;
    }
  }
  .navi-title {
    display: none;
  }
}
.navi-camera-count {
  font-size: 80px;
  color: $white;
  font-weight: bold;
  margin-top: 13px;
}
</style>
