export default async function getUserMedia(dom) {
  const video = dom;
  const medias = {
    audio: false,
    video: {},
  };
  medias.video.facingMode = { exact: 'environment' };
  return navigator.mediaDevices
    .getUserMedia(medias)
    .then(stream => {
      video.srcObject = stream;
      return true;
    })
    .catch(err => {
      console.log(err, '対応していません');
      return false;
    });
}
