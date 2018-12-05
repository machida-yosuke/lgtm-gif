<template lang="pug">
.modal
  .modal-bg.modal-bg--black(@click='close')
  .modal-policy
    .close-btn(@click='close')
      .close-btn__bar-1
      .close-btn__bar-2
    .modal-about-policy
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
</template>
<script>

export default {
  name: 'pcSitePolicyModal',
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

.modal-policy {
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
}

.modal-about-policy {
  width: 80%;
  margin: 0 auto;
}

.about__policy {
  font-weight: bold;
  font-size: 20px;
  color: $gray;
  width: 100%;
  margin: 0 auto;
  &-sentence {
    margin-top: 15px;
    font-size: 8px;
    color: $gray;
    text-align: left;
    line-height: 20px;
    white-space: pre-wrap;
  }
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
