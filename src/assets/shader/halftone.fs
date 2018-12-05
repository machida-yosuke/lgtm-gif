vec4 halftone(vec2 uv){
  float redScale   = 0.298912;
  float greenScale = 0.586611;
  float blueScale  = 0.114478;
  vec3  monochromeScale = vec3(redScale, greenScale, blueScale);

  vec4 texture = texture2D(uTexture, uv);
  float mono = dot(texture.rgb, monochromeScale);
  mono = mono * 4.0 - 2.0;

  float dotScale = 0.8;
  vec2 v = gl_FragCoord.st / dotScale;
  vec2 tone = gl_FragCoord.st / dotScale;
  float crossDot = cos(tone.s) * cos(tone.t) + 1.0;
  vec4 toneColor = vec4(vec3(crossDot + mono) * 0.5, 1.0);

  texture = mix(texture, toneColor, 1.0);

  return texture;
}