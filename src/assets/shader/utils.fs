float whiteNoise(vec2 n){
  return fract(sin(dot(n, vec2(12.9898, 4.1414))) * 43758.5453);
}

float blockNoise(vec2 uv) {
  float noise = fract(sin(dot(floor(uv * 20.0), vec2(12.9898, 78.233))) * 43758.5453);

  return sin(noise * TAU * uTime * 0.5 + PI);
}
