<template lang="pug">
.btn(:data-type='type')
  .btn-text {{text}}
</template>
<script>
export default {
  name: 'btn',
  props: ['text', 'type'],
  data() {
    return {};
  },
  computed: {},
  methods: {},
};
</script>

<style lang="scss" scoped>
.btn {
  box-shadow: 0px 0px 25px -7px $gray;
  padding: (40px * 2 - 26 * 2) 0;
  width: (97.5px * 2);
  border-radius: 46px;
  border: solid 1px $gray;
  text-align: center;
  font-size: $sentenceFontSize;
  cursor: pointer;
  &[data-type="success"] {
    background: $blue;
    color: $white;
    font-weight: bold;
  }
  &[data-type="ng"] {
    background: $white;
    color: $gray;
    font-weight: bold;
  }
  &[data-type="normal"] {
    background: $white;
    color: $gray;
  }
}
</style>
