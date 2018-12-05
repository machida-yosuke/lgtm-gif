module.exports = {
  css: {
    loaderOptions: {
      sass: {
        data: '@import "@/assets/scss/common.scss";',
      },
    },
  },
  // 今までにない設定を変える
  configureWebpack: {
    module: {
      rules: [
        {
          test: /\.(fs|vs|glsl)$/,
          use: [
            {
              loader: 'glsl-shader-loader',
            },
          ],
        },
      ],
    },
  },
};
