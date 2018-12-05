vec4 kaleidoScope(vec2 uv){
  float res = 1.75;
  float time = uTime * 2.;
  vec2 p = (uv - 0.5) * res;
  float c = cos(time), s = sin(time);
  for (int i = 1; i <= 4; ++i) {
    p = abs(p * res / 2.) - res / 4.;
  }
  p *= mat2(c, -s, s, c);
  p.x = mod(p.x, .5) * 2.0;
  p.y = mod(p.y, .5) * 2.0;
  vec4 color = texture2D(uTexture, p);
  return color;
}
