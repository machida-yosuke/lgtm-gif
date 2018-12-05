vec4 mosaic(){
  float size = 4.0;
  vec2 muv = floor(gl_FragCoord.st / size) * size / uResolution;
  vec4 texture = texture2D(uTexture, muv);
  return texture;
}