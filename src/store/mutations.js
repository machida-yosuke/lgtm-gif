export const setEffect = (state, num) => {
  state.effectNum = num;
};

export const setIsCapture = (state, bool) => {
  state.isCapturer = bool;
};

export const setLocation = (state, path) => {
  state.currentPage = path;
};

export const setGifData = (state, data) => {
  state.gifData = data;
};

export const setUa = (state, ua) => {
  state.ua = ua;
};
