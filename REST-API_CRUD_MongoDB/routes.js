// reoutes.js
const express = require('express');
const router = express.Router();
const Car = require('./models/cars');

// Fetch all cars
router.get("/cars", async (req, res) => {
  try {
    const cars = await Car.find();
    res.send(cars)
  } catch(err) {
    return res.status(500).json({ message: err.message });
  }
})

// Add car
router.post("/cars", async (req, res) => {
  const car = new Car({
    brand: req.body.brand,
    model: req.body.model,
    color: req.body.color,
    year: req.body.year
  });

  try {
    const newCar = await car.save();
    res.status(201).json({ newCar });
  } catch(err) {
    return res.status(500).json({ message: err.message });
  }
})

// Delete car by id
router.delete("/cars", async (req, res) => {
const response = await Car.deleteOne({_id: req.body.id});
  if (response.deletedCount === 0) {
    return res.status(404).json({ message: "Car not found" });
  }
  return res.status(200).json({ message: "Car deleted" });          
})

// Update car by id
router.put("/cars/:id", async (req, res) => {
   const response = await Car.findOneAndUpdate({ _id: req.params.id }, req.body, { new: true });
  if (response === null) {
    return res.status(404).json({ message: "Car not found" });
  }
  return res.status(200).json({ message: "Car updated" });

})

module.exports = router;