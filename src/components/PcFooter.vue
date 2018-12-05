<template lang="pug">
.pc-footer
  .pc-footer__copy Copyright © KAYAC Inc. All Rights Reserved.
</template>
<script>
export default {
  name: 'PcFooter',
  data() {
    return {};
  },
  computed: {},
  methods: {},
};
</script>

<style lang="scss" scoped>
.pc-footer {
  position: fixed;
  width: 100%;
  height: 50px;
  background: $white;
  bottom: 0;
  &__copy {
    display: inline-block;
    position: absolute;
    @include positionMiddle;
    font-size: $sentenceFontSize / 2;
    color: $gray;
  }
}
</style>
