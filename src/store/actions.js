export const startCapture = ({ commit }) => {
  commit('setIsCapture', true);
};

export const stopCapture = ({ commit }) => {
  commit('setIsCapture', false);
};

export const goGallery = ({ commit }) => {
  commit('setLocation', 'gallery');
};

export const goCamera = ({ commit }) => {
  commit('setLocation', 'camera');
};

export const goAbout = ({ commit }) => {
  commit('setLocation', 'about');
};

export const selectEffect = ({ commit }, num) => {
  commit('setEffect', num);
};

export const getGifData = ({ commit }, data) => {
  commit('setGifData', data);
};

export const getUa = ({ commit }, ua) => {
  commit('setUa', ua);
};
