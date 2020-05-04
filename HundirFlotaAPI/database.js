var mongoose = require('mongoose');

//Creamos la conexión con mongo
mongoose.connect('mongodb+srv://jaime:kike@cluster0-mnl9z.mongodb.net/test', { useNewUrlParser: true ,  useUnifiedTopology: true });

const db = mongoose.connection;
db.on("error", () => {
    console.log("> error occurred from the database");
});
db.once("open", () => {
    console.log("> successfully opened the database");
});

module.exports = mongoose;  //Exportamos mongoose