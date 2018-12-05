float verticalBar(float pos, float uvY, float offset) {
  float range = 0.05;
  float edge0 = (pos - range);
  float edge1 = (pos + range);
  float x = smoothstep(edge0, pos, uvY) * offset;
  x -= smoothstep(pos, edge1, uvY) * offset;
  return x;
}
