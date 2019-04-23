﻿module.exports = {
    mode: 'development',
    context: __dirname,
    entry: {
        Customer: "./Index.jsx",
        Product: "./ProductIndex.jsx",
        Store: "./StoreIndex.jsx",
        Sale: "./SaleIndex.jsx"

    },

    output: {
        path: __dirname + "/dist",
        filename: "[name].bundle.js"
    },
    watch: true,
    module: {
        rules: [{
            test: /\.jsx?$/,
            exclude: /(node_modules)/,
            use: {
                loader: 'babel-loader',
                options: {
                    presets: ['babel-preset-env', 'babel-preset-react']
                }
            }
        }]
    }
}
