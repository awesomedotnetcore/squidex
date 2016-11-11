﻿
var webpackMerge = require('webpack-merge'),
            path = require('path'),
         helpers = require('./helpers'),
      testConfig = require('./webpack.test.js');

testConfig.module.loaders.shift();

module.exports = webpackMerge(testConfig, {
    module: {
        loaders: [
            {
                test: /\.ts$/,
                include: [/\.(e2e|spec)\.ts$/],
                loaders: ['awesome-typescript']
            },
            {
                test: /\.ts$/,
                exclude: [/\.(e2e|spec)\.ts$/],
                loaders: ['istanbul-instrumenter-loader', helpers.root('app-config', 'fix-coverage-loader'), 'awesome-typescript', helpers.root('app-config', 'auto-loader') + '?[file].html=template&[file].scss=styles']
            }
        ]
    }
});

console.log(JSON.stringify(module.exports, null, 4));