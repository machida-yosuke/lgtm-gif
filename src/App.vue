<template lang="pug">
  #app
    PcHeader(v-if='ua.isPC' @openAbout='openAboutModal' @openSitePolicy='openSitePolicyModal')
    router-view
    PcFooter(v-if='ua.isPC')
    PcAboutModal(v-if='ua.isPC && isShowAboutModal' @close='closeModal')
    PcSitePolicyModal(v-if='ua.isPC && isShowSitePolicyModal' @close='closeModal')
</template>
<script>
import { mapState, mapActions } from 'vuex';
import PcHeader from '@/components/PcHeader';
import PcFooter from '@/components/PcFooter';
import PcAboutModal from '@/components/PcAboutModal';
import PcSitePolicyModal from '@/components/PcSitePolicyModal';
import getUA from '@/assets/js/getUA';

export default {
  name: 'app',
  components: {
    PcHeader,
    PcFooter,
    PcAboutModal,
    PcSitePolicyModal,
  },
  created() {
    this.getUa(getUA);
  },
  mounted() {
  },
  data() {
    return {
      isShowAboutModal: false,
      isShowSitePolicyModal: false,
    };
  },
  methods: {
    ...mapActions(['getUa']),
    openAboutModal() {
      this.isShowAboutModal = true;
    },
    openSitePolicyModal() {
      this.isShowSitePolicyModal = true;
    },
    closeModal() {
      this.isShowAboutModal = false;
      this.isShowSitePolicyModal = false;
    },
  },
  computed: {
    ...mapState(['ua']),
  },
};
</script>


<style lang="scss" scope>
#app {
  position: absolute;
  width: 100%;
  height: 100%;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
}
</style>
