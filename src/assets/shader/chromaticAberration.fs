vec4 chromaticAberration(vec2 uv){
  float PI = 3.1415;
  float moveX = sin(uTime * 100.0) * 0.02;
  float moveY = sin(uTime * 100.0 + ( PI / 4.0 )) * 0.01;
  vec4 texture = vec4(
    texture2D(uTexture, vec2(uv.x - moveX, uv.y - moveY)).r,
    texture2D(uTexture, uv).gb,
    1.0
  );

  return texture;
}
