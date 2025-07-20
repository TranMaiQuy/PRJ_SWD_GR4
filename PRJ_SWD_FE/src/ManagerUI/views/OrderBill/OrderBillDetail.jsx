// /src/ManagerUI/OrderBill/OrderBillDetail.jsx
import React, { useEffect, useState } from "react";
import axios from "axios";
import { useParams } from "react-router-dom";

export default function OrderBillDetail() {
  const { id } = useParams();
  const [order, setOrder] = useState(null);

  useEffect(() => {
    axios.get(`/api/OrderBill/detail/${id}`)
      .then(res => setOrder(res.data))
      .catch(err => console.error("Error fetching order bill:", err));
  }, [id]);

  if (!order) return <p>Loading...</p>;

  return (
    <div style={{ padding: "20px" }}>
      <h2>Order Bill Detail - #{order.orderId}</h2>
      <p><strong>Order Date:</strong> {order.orderDate}</p>
      <p><strong>Customer ID:</strong> {order.customerId}</p>
      <p><strong>Total Amount:</strong> {order.totalAmount}</p>
      <p><strong>Payment Method:</strong> {order.paymentMethod}</p>
      <p><strong>Reservation Date:</strong> {order.reservationDate}</p>
      <p><strong>Schedule Description:</strong> {order.scheduleDescription}</p>

      {order.services?.length > 0 && (
        <div>
          <h4>Services</h4>
          <ul>{order.services.map((s, i) => <li key={i}>{s}</li>)}</ul>
        </div>
      )}

      {order.prescriptions?.length > 0 && (
        <div>
          <h4>Prescriptions</h4>
          <ul>{order.prescriptions.map((p, i) => <li key={i}>{p}</li>)}</ul>
        </div>
      )}
    </div>
  );
}
