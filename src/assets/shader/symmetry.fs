vec4 symmetry(){
  float px = (gl_FragCoord.x / uResolution.x - 0.5);
  float py = (gl_FragCoord.y / uResolution.y);
  vec2 suv = vec2(px, py);
  vec2 pUv = abs(suv);
  vec4 texture = texture2D(uTexture, vec2(0.5 -pUv.x, pUv.y));
  return texture;
}