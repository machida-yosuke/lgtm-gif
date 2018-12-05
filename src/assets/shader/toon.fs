vec4 toon(vec2 uv){
  float gamma = 0.6;
  float numColors = 8.0;
  vec3 c = texture2D(uTexture, uv).rgb;
  c = pow(c, vec3(gamma, gamma, gamma));
  c = c * numColors;
  c = floor(c);
  c = c / numColors;
  c = pow(c, vec3(1.0/gamma));
  return vec4(c, 1.0);
}