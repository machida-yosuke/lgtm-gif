vec4 monochrome(vec2 uv){
  float redScale   = 0.298912;
  float greenScale = 0.586611;
  float blueScale  = 0.114478;
  vec3  monochromeScale = vec3(redScale, greenScale, blueScale);

  vec4 texture = texture2D(uTexture, uv);
  float mono = dot(texture.rgb, monochromeScale);
  float result = mono * 4.0 - 2.0;
  vec4 color = vec4(vec3(result), 1.0);

  return color;
}