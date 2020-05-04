// models/userModel.js
const mongoose = require("../database");

const schema = {
    name: { type: mongoose.SchemaTypes.String, required: true },
    email: { type: mongoose.SchemaTypes.String, required: true, unique: true }
};
const collectionName = "user"; // Name of the collection of documents

const userSchema = mongoose.Schema(schema);
const User = mongoose.model(collectionName, userSchema);

module.exports = User;