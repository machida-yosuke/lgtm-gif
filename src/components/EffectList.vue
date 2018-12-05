<template lang="pug">
  .effect-list
    swiper(:options="swiperOption" ref="mySwiper" @slideChange="setEffectNum")
      swiper-slide(v-for="effect,i in effectsList" :key='i')
        .effect-list {{effect}}
      .swiper-button-prev(slot="button-prev")
      .swiper-button-next(slot="button-next")
</template>

<script>
import { swiper, swiperSlide } from 'vue-awesome-swiper';
import { EFFECTS_LIST } from '@/assets/js/config';
import { mapState, mapActions } from 'vuex';

export default {
  name: 'effectList',
  components: {
    swiper,
    swiperSlide,
  },
  data() {
    return {
      swiperOption: {
        slidesPerView: 4,
        spaceBetween: 0,
        loop: true,
        centeredSlides: true,
        navigation: {
          nextEl: '.swiper-button-next',
          prevEl: '.swiper-button-prev',
        },
      },
    };
  },
  mounted() {
    this.selectEffect(this.swiper.realIndex);
  },
  methods: {
    ...mapActions([
      'selectEffect',
    ]),
    setEffectNum() {
      this.selectEffect(this.swiper.realIndex);
    },
  },
  computed: {
    ...mapState(['effectNum']),
    effectsList() {
      return EFFECTS_LIST;
    },
    swiper() {
      return this.$refs.mySwiper.swiper;
    },
  },
};
</script>

<style lang="scss">
.swiper-slide {
  font-weight: bold;
  font-size: $sentenceFontSize;
  cursor: pointer;
  padding-bottom: 20px;
  padding-top: 500px;
  color: #fff;
  width: auto;
  // margin: 0 auto;
  box-sizing: content-box;
}

.swiper-container {
  // position: fixed;
  z-index: 0;
}
.swiper-slide-active {
  color: $yellow !important;
}

.swiper-button-next {
  left: 375px !important;
  width: 375px;
  height: 100%;
  background: none !important;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
  -webkit-box-shadow: none;
  box-shadow: none;
  outline: none;
}
.swiper-button-prev {
  width: 375px;
  height: 100%;
  left: 0;
  background: none !important;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
  -webkit-box-shadow: none;
  box-shadow: none;
  outline: none;
}

.effect-list {
  // text-align: center !important;
}
</style>
