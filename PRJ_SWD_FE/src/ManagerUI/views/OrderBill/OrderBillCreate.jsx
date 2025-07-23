import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function OrderBillCreate() {
  const [form, setForm] = useState({
    customerId: "",
    orderDate: "",
    totalAmount: "",
    paymentMethod: "",
    reservationId: "",
    scheduleId: "",
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;

    // Ép kiểu number nếu là số
    const isNumberField = ["customerId", "totalAmount", "paymentMethod", "reservationId", "scheduleId"].includes(name);
    setForm((prev) => ({
      ...prev,
      [name]: isNumberField ? parseInt(value) || 0 : value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    // Kiểm tra nhanh trước khi gửi
    if (!form.orderDate) {
      alert("Please select an order date.");
      return;
    }

    fetch("https://localhost:7012/api/OrderBill/create", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then(res => {
        if (!res.ok) throw new Error("Create failed");
        return res.json();
      })
      .then(() => {
        alert("Order Bill created successfully!");
        navigate("/orderbill");
      })
      .catch((err) => {
        console.error("Create failed", err);
        alert("Failed to create Order Bill. Check console for details.");
      });
  };

  return (
    <form onSubmit={handleSubmit} style={{ padding: "20px" }}>
      <h2>Create Order Bill</h2>

      <label>Customer ID:</label>
      <input
        name="customerId"
        type="number"
        value={form.customerId}
        onChange={handleChange}
        required
      />

      <label>Order Date:</label>
      <input
        name="orderDate"
        type="date"
        value={form.orderDate}
        onChange={handleChange}
        required
      />

      <label>Total Amount:</label>
      <input
        name="totalAmount"
        type="number"
        value={form.totalAmount}
        onChange={handleChange}
        required
      />

      <label>Payment Method:</label>
      <input
        name="paymentMethod"
        type="number"
        value={form.paymentMethod}
        onChange={handleChange}
        required
      />

      <label>Reservation ID:</label>
      <input
        name="reservationId"
        type="number"
        value={form.reservationId}
        onChange={handleChange}
        required
      />

      <label>Schedule ID:</label>
      <input
        name="scheduleId"
        type="number"
        value={form.scheduleId}
        onChange={handleChange}
        required
      />

      <br /><br />
      <button type="submit">Create</button>
    </form>
  );
}
