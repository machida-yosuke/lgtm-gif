vec4 normal(vec2 uv){
  vec4 texture = texture2D(uTexture, uv);
  return texture;
}