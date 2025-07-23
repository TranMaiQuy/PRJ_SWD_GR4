import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

export default function OrderBill() {
  const [data, setData] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetch("https://localhost:7012/api/OrderBill/list")
      .then(res => {
        if (!res.ok) throw new Error("Failed to fetch order bills");
        return res.json();
      })
      .then(setData)
      .catch((err) => console.error("Failed to load order bills", err));
  }, []);

  const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this order?")) {
      fetch(`https://localhost:7012/api/OrderBill/${id}`, { method: "DELETE" })
        .then(res => {
          if (!res.ok) throw new Error("Delete failed");
          setData(prev => prev.filter(order => order.orderId !== id));
        })
        .catch(err => console.error("Delete failed", err));
    }
  };

  return (
    <div style={{ padding: "20px" }}>
      <h2>Order Bills</h2>
      <button onClick={() => navigate("/orderbill/create")}>+ Create New Order</button>

      <table border="1" cellPadding="8" cellSpacing="0" style={{ marginTop: "20px", width: "100%" }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Customer</th>
            <th>Date</th>
            <th>Total</th>
            <th>Payment</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {data.length === 0 ? (
            <tr><td colSpan="6">No order bills found.</td></tr>
          ) : (
            data.map(order => (
              <tr key={order.orderId}>
                <td>{order.orderId}</td>
                <td>{order.customerId}</td>
                <td>{order.orderDate?.substring(0, 10)}</td>
                <td>{order.totalAmount}</td>
                <td>{order.paymentMethod}</td>
                <td>
                  <button onClick={() => navigate(`/orderbill/detail/${order.orderId}`)}>View</button>
                  <button onClick={() => navigate(`/orderbill/edit/${order.orderId}`)}>Edit</button>
                  <button onClick={() => handleDelete(order.orderId)}>Delete</button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
