import qs from 'querystring';

/**
 * Twitterシェア用のリンクをつくる
 * @param {String} opts.url シェアしたいURL
 * @param {String} opts.text シェア文言
 * @param {String} opts.hashtags ハッシュタグ
 * @return {String}
 */
export function createTwitterIntent(opts = {}) {
  return `http://twitter.com/intent/tweet?${qs.stringify(opts)}`;
}

/**
 * Facebookシェア用のリンクをつくる
 * @param {String} シェアしたいURL
 * @return {String}
 */
export function createFacebookIntent(u) {
  return `http://www.facebook.com/share.php?${qs.stringify({ u })}`;
}

export const opts = {
  url: 'https://cl-fibe-conf-lgtm-1302249.firebaseapp.com',
  text: 'あなただけのオリジナルLGTM GIF動画を作ろう！',
  hashtags: 'html5j,HTML5,html5j_a,HTML5Conference2018 ',
};
