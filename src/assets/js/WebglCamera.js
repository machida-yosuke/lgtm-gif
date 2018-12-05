import * as THREE from 'three';
import { TweenMax } from 'gsap/TweenMax';
import EventEmitter from 'events';
import frag from '../shader/fragment.fs';
import vert from '../shader/vertex.vs';
import Capture from '@/assets/js/Capture';
import { framerate, timeLimit, EFFECTS_LIST } from './config';

TweenMax.ticker.fps(30);
TweenMax.lagSmoothing(1000, 20);

// エッジフィルタのカーネル
const LAPLACIAN = [-1.0, -1.0, -1.0, -1.0, 8.0, -1.0, -1.0, -1.0, -1.0];
export default class WebglCamera extends EventEmitter {
  constructor() {
    super();
    this.capturer = new Capture();
  }

  setDom(canvas, video) {
    this.canvas = canvas;
    this.video = video;
    this.isCapturer = false;
    this.clock = new THREE.Clock();
    this.count = 0;
    this.initThree();
  }

  setEffect(num) {
    this.effect = EFFECTS_LIST[num];
    this.uniforms.uIsSymmetry.value = 0.0;
    this.uniforms.uIsNormal.value = 0.0;
    this.uniforms.uIsMosaic.value = 0.0;
    this.uniforms.uIsMonochrome.value = 0.0;
    this.uniforms.uIsHsv.value = 0.0;
    this.uniforms.uIsHalftone.value = 0.0;
    this.uniforms.uIsInverse.value = 0.0;
    this.uniforms.uIsEdge.value = 0.0;
    this.uniforms.uIsInsta.value = 0.0;
    this.uniforms.uIsChromatic.value = 0.0;
    this.uniforms.uIsKaleidoScope.value = 0.0;
    this.uniforms.uIsVhs.value = 0.0;
    this.uniforms.uIsToon.value = 0.0;
    this.uniforms.uIsGlitch.value = 0.0;
    this.uniforms.uIsSen.value = 0.0;

    switch (this.effect) {
    case 'シンメトリー':
      this.uniforms.uIsSymmetry.value = 1.0;
      break;
    case 'ノーマル':
      this.uniforms.uIsNormal.value = 1.0;
      break;
    case 'モザイク':
      this.uniforms.uIsMosaic.value = 1.0;
      break;
    case '白黒':
      this.uniforms.uIsMonochrome.value = 1.0;
      break;
    case 'hsv':
      this.uniforms.uIsHsv.value = 1.0;
      break;
    case 'ハーフトーン':
      this.uniforms.uIsHalftone.value = 1.0;
      break;
    case 'エッジ':
      this.uniforms.uIsEdge.value = 1.0;
      break;
    case 'インスタ':
      this.uniforms.uIsInsta.value = 1.0;
      break;
    case '色反転':
      this.uniforms.uIsInverse.value = 1.0;
      break;
    case '色収差':
      this.uniforms.uIsChromatic.value = 1.0;
      break;
    case 'VHS':
      this.uniforms.uIsVhs.value = 1.0;
      break;
    case '万華鏡':
      this.uniforms.uIsKaleidoScope.value = 1.0;
      break;
    case 'トゥーン':
      this.uniforms.uIsToon.value = 1.0;
      break;
    case 'グリッチ':
      this.uniforms.uIsGlitch.value = 1.0;
      break;
    case '線':
      this.uniforms.uIsSen.value = 1.0;
      break;

    default:
      this.uniforms.uIsNormal.value = 1.0;
      break;
    }
  }

  initThree() {
    this.width = this.video.videoWidth;
    this.height = this.video.videoHeight;
    this.canvas.width = this.width;
    this.canvas.height = this.height;
    this.videoTexture = new THREE.VideoTexture(this.video);
    this.videoTexture.minFilter = THREE.LinearFilter;
    this.videoTexture.magFilter = THREE.LinearFilter;
    this.videoTexture.mapping = THREE.ClampToEdgeWrapping;
    this.videoTexture.format = THREE.RGBFormat;

    this.scene = new THREE.Scene();
    this.camera = new THREE.PerspectiveCamera(
      40,
      this.width / this.height,
      0.1,
      2,
    );
    this.camera.lookAt(new THREE.Vector3(0.0, 0.0, 0.0));
    this.camera.position.z = 1;

    this.renderer = new THREE.WebGLRenderer({ canvas: this.canvas });
    this.renderer.setClearColor(0xffffff);
    this.renderer.setSize(this.width / 2, this.height / 2);
    this.renderer.setPixelRatio(1);

    this.uniforms = {
      uTexture: {
        type: 't',
        value: this.videoTexture,
      },
      uTime: {
        type: 'f',
        value: this.time,
      },
      uResolution: {
        type: 'v2',
        value: [this.width / 2, this.height / 2],
      },
      uIsNormal: {
        type: 'f',
        value: 1.0,
      },
      uIsSymmetry: {
        type: 'f',
        value: 0.0,
      },
      uIsMosaic: {
        type: 'f',
        value: 0.0,
      },
      uIsMonochrome: {
        type: 'f',
        value: 0.0,
      },
      uIsHsv: {
        type: 'f',
        value: 0.0,
      },
      uIsHalftone: {
        type: 'f',
        value: 0.0,
      },
      uIsEdge: {
        type: 'f',
        value: 0.0,
      },
      uIsInsta: {
        type: 'f',
        value: 0.0,
      },
      uIsInverse: {
        type: 'f',
        value: 0.0,
      },
      uLaplacian: {
        type: '1fv',
        value: LAPLACIAN,
      },
      uIsChromatic: {
        type: 'f',
        value: 0.0,
      },
      uIsKaleidoScope: {
        type: 'f',
        value: 0.0,
      },
      uIsVhs: {
        type: 'f',
        value: 0.0,
      },
      uIsToon: {
        type: 'f',
        value: 0.0,
      },
      uIsGlitch: {
        type: 'f',
        value: 0.0,
      },
      uIsSen: {
        type: 'f',
        value: 0.0,
      },
    };

    const mesh = new THREE.Mesh(
      new THREE.PlaneGeometry(0.75, 1),
      new THREE.RawShaderMaterial({
        fragmentShader: frag,
        vertexShader: vert,
        uniforms: this.uniforms,
      }),
    );
    this.scene.add(mesh);

    // レンダリング
    this.render = () => {
      this.time = this.clock.getElapsedTime();
      this.uniforms.uTime.value = this.time;

      this.renderer.render(this.scene, this.camera);
      this.videoTexture.needsUpdate = true;

      if (this.isCapturer && this.count === framerate * timeLimit) {
        this.isCapturer = false;
        this.count = 0;
        this.capturer.stop();
        this.emit('captureComp');
        this.capturer.save().then(blob => {
          this.emit('saveComp', blob);
        });

        TweenMax.ticker.fps(30);
        this.capturer = new Capture();
      }
      if (this.isCapturer) {
        this.count += 1;
        this.emit('decrementCount', this.count);
        this.capturer.capture(this.canvas);
      }
    };
    TweenMax.ticker.addEventListener('tick', this.render);
  }

  startCapture() {
    this.isCapturer = true;
    TweenMax.ticker.fps(framerate);
    this.capturer.start();
  }

  destroy() {
    TweenMax.ticker.removeEventListener('tick', this.render);
  }
}
