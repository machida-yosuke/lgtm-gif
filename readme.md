# cl-lgtm-panel

vue-cli3 をつかってるよん

```
yarn serve
```

で開発開始

```
yarn build
```

でビルド開始

## firebase

開発にあたって自身で firebase の設定をお願いします。

firebaseConfig.js を
src
-assets
-js
におく

```
const config = {
  apiKey: '●●●●●●',
  authDomain: '●●●●●●',
  databaseURL: '●●●●●●',
  projectId: '●●●●●●',
  storageBucket: '●●●●●●',
  messagingSenderId: '●●●●●●',
};
export default config;

```

をコピペ

## カメラフィルタ ー（shader）の追加方法

src
-assets
-shader

fragment.fs は最終出力
基本的に unifrom でエフェクトの切り分けを行う

PC でデバックする場合は

```
getUserMedia.js
medias.video.facingMode = { exact: 'environment' };
```

をコメントアウトしよう

### 例）ノイズエフェクトを追加する場合

config.js の EFFECTS_LIST に
フィルタ ー 名

```
ノイズ
```

を追加

webglCamera.js の setEffect 関数内で unifrom を設定

```
this.uniforms.uIsNoise.value = 0.0;
```

関数内部の switch 文に条件式を書く

```
case 'ノイズ':
  this.uniforms.uIsNoise.value = 1.0;
  break;
```

initThree 関数内で unifrom を設定

```
uIsNoise: {
  type: 'f',
  value: 0.0,
},
```

そのほか uniforms に別のテクスチャやマウスの位置などを追加したい場合は要相談

fragment.fs 内に uniform を読み込ませる

```
uniform float uIsNoise;
```

次に fragment shader を記述
noise.fs を作成
fragment.fs 内で import するので、vec4 型を返す関数を記述すること

```
#pragma loader: import noise from './noise.fs';
vec4 noise = noise(texcoord) * uIsNoise;
vec4 color = symmetry + normal +... + noise;
```
