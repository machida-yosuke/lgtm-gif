<template lang="pug">
.about
  .about-wrap
    .about__title About App
    .about__image
      .about__image-lgtm
      .about__image-kayac
    h1.about__info あなただけのオリジナルLGTM GIF動画を作ろう！カメラで撮影するとGIF動画が生成され、デジタルサイネージにそのまま反映されます！用意されたカメラフィルターを使えば、よりクリエイティブなLGTM GIF動画が作れるかも？
    .about__line
    .about__share Share
    .about__share-image
      a.about__share-image-twitter(:href='twitterLink' target='_blank')
      a.about__share-image-facebook(:href='facebookLink' target='_blank')
    .about__line
    .about__staffs STAFF
      a.about__staff(href='https://www.kayac.com/team/machida-yosuke' target='_blank') Director : Machida Yosuke
      a.about__staff(href='https://www.kayac.com/team/machida-yosuke' target='_blank') Designer : Machida Yosuke
      a.about__staff(href='https://www.kayac.com/team/machida-yosuke' target='_blank') Frontend : Machida Yosuke
      a.about__staff(href='https://www.kayac.com/team/irie-shinnosuke' target='_blank') Frontend : Irie Shinnosuke
      a.about__staff(href='https://www.kayac.com/team/tagami-mio' target='_blank') Frontend : Tagami Mio
      a.about__staff(href='https://www.kayac.com/team/himeno-yusuke' target='_blank') Frontend : Himeno Yusuke
      a.about__staff(href='https://www.kayac.com/' target='_blank') Frontend : Suzuki Ryota
      a.about__staff(href='https://www.kayac.com/team/fujisawa-shin' target='_blank') Support : Fujisawa Shin
    .about__line
    .about__policy サイトポリシー
      .about__policy-sentence 本サイトを利用された場合は、以下の内容について同意したものとみなされます。
      .about__policy-sentence １．本サイトをユーザーが利用する場合、インターネットにアクセスする必要がありますが、そのためのあらゆる機器、ソフトウェア、通信手段はユーザーご自身が各自の責任と費用において適切に準備、設置、操作していただく必要があります。ユーザーのアクセス環境について一切関与せず、これらの準備、操作に関する責任を負いません。
      .about__policy-sentence 2．本サイト上においてユーザーが開示した全ての情報に関する責任は、ユーザー各自にあります。従って、ユーザーが本サイトにおいて投稿を行った情報について、一切の責任を負いません。
      .about__policy-sentence 3．ユーザーが他人の名誉を毀損した場合、プライバシー権を侵害した場合、著作権法に違反する行為を行った場合その他他人の権利を侵害した場合、当該ユーザーは自身の責任と費用において解決しなければならず、一切の責任を負いません。
      .about__policy-sentence 4．ユーザーが開示した情報が原因となって迷惑を受けたとする者が現れた場合には、当該ユーザーは自身の責任と費用において解決しなければならず、一切の責任を負いません。
      .about__policy-sentence 5．本サイトの利用した又は利用できなかったことにより生じたトラブル、損害等について、一切の責任を負わないものとします。
      .about__policy-sentence 6．本サイトに掲載されている情報、コンテンツについて、完全性、正確性、信頼性、有用性等に関する保証を行いません。
      .about__policy-sentence 7．事前予告なしに本サイトの内容の変更、運営の中断、中止行うことがあります。これらによって生じたいかなるトラブル・損害等に対しても責任を負うものではありません。
      .about__policy-sentence 8．本サイトを監視する義務を負いません。本サイトを利用したことでユーザーまたは他者に発生した損害について、一切責任を負いません。
      .about__policy-sentence 9. ユーザーは、本サービスを利用するに際し、以下のような違法行為を行ってはなりません。著作権、特許権等の知的財産権を侵害する行為、他者のプライバシー、肖像権を侵害する行為、公序良俗に反するかあるいは社会的に不適切な行動と解される行為
    .about__copy Copyright © KAYAC Inc. All Rights Reserved.
  Navi(v-if='ua.isSP')
</template>
<script>
import Navi from '@/components/Navi';

import { mapActions, mapState } from 'vuex';
import { opts, createTwitterIntent, createFacebookIntent } from '@/assets/js/share';

export default {
  name: 'about',
  components: {
    Navi,
  },
  created() {
    if (this.ua.isPC) {
      this.$router.push({ path: '/' });
    }
    this.goAbout();
  },
  data() {
    return {};
  },
  computed: {
    ...mapState(['ua']),
    twitterLink() {
      return createTwitterIntent(opts);

    },
    facebookLink() {
      return createFacebookIntent(opts.url);
    },
  },
  methods: {
    ...mapActions(['goAbout']),
  },
};
</script>

<style lang="scss" scoped>
.about {
  position: absolute;
  top: 0;
  left: 0;
  width: 750px;
  height: 100%;
  overflow: hidden;
  background: $white;
}

.about-wrap {
  width: 750px;
  height: calc(100% - 86px);
  overflow-y: auto;
  overflow-x: hidden;
  -webkit-overflow-scrolling: touch;
}

.about__title {
  margin-top: 50px;
  font-size: 60px;
  text-align: center;
  font-weight: bold;
  color: $gray;
}

.about__image {
  display: flex;
  margin: 50px auto;
  width: 400px;
  justify-content: space-between;
  align-items: flex-end;
  &-lgtm {
    @include set-image("common/lgtm-logo.png", 220px, 154px);
  }
  &-kayac {
    @include set-image("common/kayac-logo.svg", 140px, 140px);
  }
}

.about__info {
  font-weight: bold;
  margin: 0 auto;
  text-align: left;
  line-height: 52px;
  width: 70%;
  font-size: $sentenceFontSize;
  color: $gray;
}

.about__share {
  display: block;
  font-weight: bold;
  margin-top: 50px;
  font-size: 40px;
  color: $gray;
}

.about__share-image {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  width: 200px;
  margin: 30px auto 0;
  &-twitter {
    cursor: pointer;
    @include set-image("common/twitter.svg", 80px, 80px);
  }
  &-facebook {
    cursor: pointer;
    @include set-image("common/facebook.svg", 80px, 80px);
  }
}

.about__line {
  width: 80%;
  height: 1px;
  background: $gray;
  margin: 50px auto;
}

.about__staffs {
  font-weight: bold;
  font-size: 40px;
  color: $gray;
}

.about__staff {
  display: block;
  margin-top: 30px;
  font-size: 16px;
  color: $gray;
}

.about__policy {
  font-weight: bold;
  font-size: 40px;
  color: $gray;
  width: 80%;
  margin: 0 auto;
  &-sentence {
    margin-top: 30px;
    font-size: 16px;
    color: $gray;
    text-align: left;
    line-height: 30px;
    white-space: pre-wrap;
  }
}

.about__copy {
  margin: 50px 0;
  font-size: 16px;
  color: $gray;
}
</style>
