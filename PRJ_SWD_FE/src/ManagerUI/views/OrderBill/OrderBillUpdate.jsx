import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";

export default function OrderBillUpdate() {
  const { id } = useParams();
  const [form, setForm] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    axios.get(`/api/OrderBill/detail/${id}`)
      .then((res) => setForm(res.data))
      .catch((err) => console.error("Load failed", err));
  }, [id]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.put(`/api/OrderBill/${id}`, form)
      .then(() => navigate("/orderbill"))
      .catch((err) => console.error("Update failed", err));
  };

  if (!form) return <p>Loading...</p>;

  return (
    <form onSubmit={handleSubmit}>
      <h2>Edit Order Bill</h2>
      <input name="customerId" value={form.customerId} onChange={handleChange} required />
      <input name="orderDate" type="date" value={form.orderDate?.substring(0, 10)} onChange={handleChange} required />
      <input name="totalAmount" type="number" value={form.totalAmount} onChange={handleChange} required />
      <input name="paymentMethod" value={form.paymentMethod} onChange={handleChange} required />
      <button type="submit">Update</button>
    </form>
  );
}
