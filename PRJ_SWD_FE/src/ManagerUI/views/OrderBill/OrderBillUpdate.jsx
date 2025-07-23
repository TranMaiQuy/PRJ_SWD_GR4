import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

export default function OrderBillUpdate() {
  const { id } = useParams();
  const [form, setForm] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetch(`https://localhost:7012/api/OrderBill/detail/${id}`)
      .then(res => res.json())
      .then(data => setForm(data))
      .catch(err => console.error("Load failed", err));
  }, [id]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch(`https://localhost:7012/api/OrderBill/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then(res => {
        if (!res.ok) throw new Error("Update failed");
        navigate("/orderbill");
      })
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
