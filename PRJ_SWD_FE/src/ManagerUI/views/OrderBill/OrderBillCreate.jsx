import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function OrderBillCreate() {
  const [form, setForm] = useState({
    customerId: "",
    orderDate: "",
    totalAmount: "",
    paymentMethod: "",
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post("/api/OrderBill", form)
      .then(() => navigate("/orderbill"))
      .catch((err) => console.error("Create failed", err));
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create Order Bill</h2>
      <input name="customerId" placeholder="Customer ID" onChange={handleChange} required />
      <input name="orderDate" type="date" onChange={handleChange} required />
      <input name="totalAmount" type="number" onChange={handleChange} required />
      <input name="paymentMethod" placeholder="Payment Method" onChange={handleChange} required />
      <button type="submit">Create</button>
    </form>
  );
}
