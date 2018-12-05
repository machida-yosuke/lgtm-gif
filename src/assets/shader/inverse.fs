vec4 inverse(vec2 uv){
  vec4 texture = texture2D(uTexture, uv);
  vec4 color = vec4(vec3(1.0 - texture), 1.0);
  return color;
}
