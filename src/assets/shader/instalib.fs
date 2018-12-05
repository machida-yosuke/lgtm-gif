float greyScale(vec3 col) {
    return dot(col, vec3(0.3, 0.59, 0.11));
}

mat3 saturationMatrix(float saturation) {
    vec3 luminance = vec3( 0.3086, 0.6094, 0.0820 );
    float oneMinusSat = 1.0 - saturation;
    vec3 red = vec3( luminance.x * oneMinusSat );
    red.r += saturation;
    vec3 green = vec3( luminance.y * oneMinusSat );
    green.g += saturation;
    vec3 blue = vec3( luminance.z * oneMinusSat );
    blue.b += saturation;
    return mat3(red, green, blue);
}

vec3 levels(vec3 col, vec3 inleft, vec3 inright, vec3 outleft, vec3 outright) {
    col = clamp(col, inleft, inright);
    col = (col - inleft) / (inright - inleft);
    col = outleft + col * (outright - outleft);
    return col;
}

vec3 levelsGamma(vec3 col, vec3 inleft, vec3 inright, vec3 outleft, vec3 outright, vec3 gamma1, vec3 gamma2) {
    col = clamp(col, inleft, inright);
    col = (col - inleft) / (inright - inleft);
    col = pow(col, gamma2); 
    col = outleft + col * (outright - outleft);
    col = pow(col, gamma1);
    return col;
}


vec3 levelsGamma2(vec3 col, vec3 inleft, vec3 inright, vec3 outleft, vec3 outright, 
    vec3 gamma1, vec3 gamma2, float ileft, float iright, float oleft, float oright) {
    col = clamp(col, inleft, inright);
    col = (col - inleft) / (inright - inleft);
    col = pow(col, gamma2); 
    col = outleft + col * (outright - outleft);
    col = (col - vec3(ileft)) / vec3(iright - ileft); 
    col = pow(col, gamma1);
    col = vec3(oleft) + col * (oright - oleft); 
    return col;
}

vec3 brightnessAdjust(vec3 color, float b) {
    color += b;
    return color;
}

vec3 contrastAdjust(vec3 color, float c) {
    float t = 0.5 - c * 0.5; 
    color = color * c + t;
    return color;
}


vec3 colorBurn(vec3 s, vec3 d ){
    return 1.0 - (1.0 - d) / s;
}
