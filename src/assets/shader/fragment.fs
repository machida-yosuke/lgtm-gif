precision highp float;

uniform sampler2D uTexture;
uniform float uTime;
uniform vec2 uResolution;
uniform float uIsSymmetry;
uniform float uIsNormal;
uniform float uIsMosaic;
uniform float uIsMonochrome;
uniform float uIsHsv;
uniform float uIsHalftone;
uniform float uIsInverse;
uniform float uIsEdge;
uniform float uIsInsta;
uniform float uLaplacian[9];
uniform float uIsChromatic;
uniform float uIsKaleidoScope;
uniform float uIsVhs;
uniform float uIsToon;
uniform float uIsGlitch;
uniform float uIsSen;

varying vec2 vUv;

const float PI = 3.14;
const float TAU = PI * 2.0;

// // Description : Array and textureless GLSL 2D/3D/4D simplex
//               noise functions.
//      Author : Ian McEwan, Ashima Arts.
//  Maintainer : stegu
//     Lastmod : 20110822 (ijm)
//     License : Copyright (C) 2011 Ashima Arts. All rights reserved.
//               Distributed under the MIT License. See LICENSE file.
//               https://github.com/ashima/webgl-noise
//               https://github.com/stegu/webgl-noise
//

vec3 mod289(vec3 x) {
  return x - floor(x * (1.0 / 289.0)) * 289.0;
}

vec4 mod289(vec4 x) {
  return x - floor(x * (1.0 / 289.0)) * 289.0;
}

vec4 permute(vec4 x) {
     return mod289(((x*34.0)+1.0)*x);
}

vec4 taylorInvSqrt(vec4 r)
{
  return 1.79284291400159 - 0.85373472095314 * r;
}

float snoise(vec3 v)
{
  const vec2  C = vec2(1.0/6.0, 1.0/3.0) ;
  const vec4  D = vec4(0.0, 0.5, 1.0, 2.0);

// First corner
  vec3 i  = floor(v + dot(v, C.yyy) );
  vec3 x0 =   v - i + dot(i, C.xxx) ;

// Other corners
  vec3 g = step(x0.yzx, x0.xyz);
  vec3 l = 1.0 - g;
  vec3 i1 = min( g.xyz, l.zxy );
  vec3 i2 = max( g.xyz, l.zxy );

  //   x0 = x0 - 0.0 + 0.0 * C.xxx;
  //   x1 = x0 - i1  + 1.0 * C.xxx;
  //   x2 = x0 - i2  + 2.0 * C.xxx;
  //   x3 = x0 - 1.0 + 3.0 * C.xxx;
  vec3 x1 = x0 - i1 + C.xxx;
  vec3 x2 = x0 - i2 + C.yyy; // 2.0*C.x = 1/3 = C.y
  vec3 x3 = x0 - D.yyy;      // -1.0+3.0*C.x = -0.5 = -D.y

// Permutations
  i = mod289(i);
  vec4 p = permute( permute( permute(
             i.z + vec4(0.0, i1.z, i2.z, 1.0 ))
           + i.y + vec4(0.0, i1.y, i2.y, 1.0 ))
           + i.x + vec4(0.0, i1.x, i2.x, 1.0 ));

// Gradients: 7x7 points over a square, mapped onto an octahedron.
// The ring size 17*17 = 289 is close to a multiple of 49 (49*6 = 294)
  float n_ = 0.142857142857; // 1.0/7.0
  vec3  ns = n_ * D.wyz - D.xzx;

  vec4 j = p - 49.0 * floor(p * ns.z * ns.z);  //  mod(p,7*7)

  vec4 x_ = floor(j * ns.z);
  vec4 y_ = floor(j - 7.0 * x_ );    // mod(j,N)

  vec4 x = x_ *ns.x + ns.yyyy;
  vec4 y = y_ *ns.x + ns.yyyy;
  vec4 h = 1.0 - abs(x) - abs(y);

  vec4 b0 = vec4( x.xy, y.xy );
  vec4 b1 = vec4( x.zw, y.zw );

  //vec4 s0 = vec4(lessThan(b0,0.0))*2.0 - 1.0;
  //vec4 s1 = vec4(lessThan(b1,0.0))*2.0 - 1.0;
  vec4 s0 = floor(b0)*2.0 + 1.0;
  vec4 s1 = floor(b1)*2.0 + 1.0;
  vec4 sh = -step(h, vec4(0.0));

  vec4 a0 = b0.xzyw + s0.xzyw*sh.xxyy ;
  vec4 a1 = b1.xzyw + s1.xzyw*sh.zzww ;

  vec3 p0 = vec3(a0.xy,h.x);
  vec3 p1 = vec3(a0.zw,h.y);
  vec3 p2 = vec3(a1.xy,h.z);
  vec3 p3 = vec3(a1.zw,h.w);

//Normalise gradients
  vec4 norm = taylorInvSqrt(vec4(dot(p0,p0), dot(p1,p1), dot(p2, p2), dot(p3,p3)));
  p0 *= norm.x;
  p1 *= norm.y;
  p2 *= norm.z;
  p3 *= norm.w;

// Mix final noise value
  vec4 m = max(0.6 - vec4(dot(x0,x0), dot(x1,x1), dot(x2,x2), dot(x3,x3)), 0.0);
  m = m * m;
  return 42.0 * dot( m*m, vec4( dot(p0,x0), dot(p1,x1),
                                dot(p2,x2), dot(p3,x3) ) );
}

#pragma loader: import normal from './normal.fs';
#pragma loader: import symmetry from './symmetry.fs';
#pragma loader: import inverse from './inverse.fs';
#pragma loader: import monochrome from './monochrome.fs';
#pragma loader: import mosaic from './mosaic.fs';
#pragma loader: import hsv from './hsv.fs';
#pragma loader: import halftone from './halftone.fs';
#pragma loader: import edge from './edge.fs';
#pragma loader: import insta from './insta.fs';
#pragma loader: import chromaticAberration from './chromaticAberration.fs';
#pragma loader: import kaleidoScope from './kaleidoScope.fs';
#pragma loader: import vhs from './vhs.fs';
#pragma loader: import toon from './toon.fs';
#pragma loader: import glitch from './glitch.fs';
#pragma loader: import sen from './sen.fs';

void main () {
  vec2 texcoord = gl_FragCoord.st / uResolution;
  // -1 ~ 1にするやーつ
  vec2 p = texcoord * 2.0 - 1.0;

  vec4 normal = normal(texcoord) * uIsNormal;
  vec4 symmetry = symmetry() * uIsSymmetry;
  vec4 monochrome = monochrome(texcoord) * uIsMonochrome;
  vec4 mosaic = mosaic() * uIsMosaic;
  vec4 hsv = hsv(texcoord) * uIsHsv;
  vec4 Halftone = halftone(texcoord) * uIsHalftone;
  vec4 inverse = inverse(texcoord) * uIsInverse;
  vec4 edge = edge(texcoord) * uIsEdge;
  vec4 insta = insta(texcoord, p) * uIsInsta;
  vec4 chromaticAberration = chromaticAberration(texcoord) * uIsChromatic;
  vec4 vhs = vhs(texcoord, p) * uIsVhs;
  vec4 kaleidoScope = kaleidoScope(texcoord) * uIsKaleidoScope;
  vec4 toon = toon(texcoord) * uIsToon;
  vec4 glitch = glitch(texcoord) * uIsGlitch;
  vec4 sen = sen(texcoord) * uIsSen;

  vec4 color = toon + symmetry + normal + monochrome + mosaic + hsv + Halftone + edge + insta + inverse + vhs + kaleidoScope + chromaticAberration + glitch + sen;

  gl_FragColor = color;
}
