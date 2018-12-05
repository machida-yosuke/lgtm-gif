<template lang="pug">
.pc-header
  .heder-contents
    .heder-contents__logo
    .heder-contents__nav
      a.heder-contents__nav-about(@click='openSitePoclicy') サイトポリシー
      a.heder-contents__nav-sitepolicy(@click='openAbout') 本サイトについて
      a.heder-contents__nav-twitter(:href='twitterLink' target='_blank')
      a.heder-contents__nav-facebook(:href='facebookLink' target='_blank')
</template>
<script>
import { opts, createTwitterIntent, createFacebookIntent } from '@/assets/js/share';

export default {
  name: 'PcHeader',
  data() {
    return {};
  },
  computed: {
    twitterLink() {
      return createTwitterIntent(opts);

    },
    facebookLink() {
      return createFacebookIntent(opts.url);
    },
  },
  methods: {
    openAbout() {
      this.$emit('openAbout');
    },
    openSitePoclicy() {
      this.$emit('openSitePolicy');
    },
  },
};
</script>

<style lang="scss" scoped>
.pc-header {
  height: 80px;
  width: 100%;
  background: $white;
  position: fixed;
  top: 0;
  left: 0;
  border-bottom: solid 1px $gray;
}

.heder-contents {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  max-width: 1200px;
  width: 80%;
  position: absolute;
  @include positionMiddle;
  &__logo {
    @include set-image("common/lgtm-motion.gif", 100px, 62px);
  }
}

.heder-contents__nav {
  display: flex;
  align-items: flex-end;
  &-sitepolicy {
    font-size: 13px;
    color: $gray;
  }
  &-about {
    font-size: 13px;
    color: $gray;
    margin: 0 20px;
  }
  &-twitter {
    @include set-image("common/twitter.svg", 30px, 25px);
    margin: 0 20px;
  }
  &-facebook {
    @include set-image("common/facebook.svg", 25px, 25px);
  }
}
</style>
