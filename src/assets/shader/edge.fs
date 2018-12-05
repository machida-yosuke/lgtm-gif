vec4 edge(vec2 uv){
  vec2 pxSize = 1.0 / uResolution;
  vec2 offset[9];
  offset[0] = uv + (vec2(-1.0,  1.0) * pxSize);
  offset[1] = uv + (vec2( 0.0,  1.0) * pxSize);
  offset[2] = uv + (vec2( 1.0,  1.0) * pxSize);
  offset[3] = uv + (vec2(-1.0,  0.0) * pxSize);
  offset[4] = uv + (vec2( 0.0,  0.0) * pxSize);
  offset[5] = uv + (vec2( 1.0,  0.0) * pxSize);
  offset[6] = uv + (vec2(-1.0, -1.0) * pxSize);
  offset[7] = uv + (vec2( 0.0, -1.0) * pxSize);
  offset[8] = uv + (vec2( 1.0, -1.0) * pxSize);
  vec3 dist = vec3(0.0);

  for(int i = 0; i < 9; ++i){
    dist += texture2D(uTexture, offset[i]).rgb * uLaplacian[i];
  }
  vec4 texture = texture2D(uTexture, uv);

  vec4 color = vec4(dist, 1.0) / texture;
  return color;
}