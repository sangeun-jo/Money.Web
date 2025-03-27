const webpack = require("webpack");
const path = require("path");

const isDevelopment = process.env.NODE_ENV !== "production";

module.exports = {
    mode: isDevelopment ? "development" : "production",
    entry: [
        "./wwwroot/js/index.js"
    ],
    output: {
        path: path.resolve(__dirname, "wwwroot/js"),
        filename: "index.bundle.js",
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use : [
                    {
                        loader: 'style-loader',
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true,
                        }
                    }
                ]
            }
        ]
    }
};