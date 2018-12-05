import { framerate } from './config';

export default class Capture {
  constructor() {
    this.capturer = new CCapture({
      framerate,
      verbose: true,
      format: 'gif',
      workersPath: './js/',
    });
  }

  start() {
    this.capturer.start();
  }

  stop() {
    this.capturer.stop();
  }

  capture(canvas) {
    this.capturer.capture(canvas);
  }

  save() {
    // this.capturer.save();
    // 外部スマホはアップロードさせない
    // window.location.href = URL.createObjectURL(blob);

    return new Promise(resolve => {
      this.capturer.save(blob => {
        console.log(blob);
        resolve(blob);
      });
    });
  }
}
