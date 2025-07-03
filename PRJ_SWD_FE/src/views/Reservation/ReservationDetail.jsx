import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom"; // 👉 import useParams để lấy ID từ URL

function ReservationDetail() {
  const { id } = useParams(); // 👈 Lấy reservationId từ URL
  const [reservation, setReservation] = useState(null);

  useEffect(() => {
    const fetchReservation = async () => {
      try {
        const response = await fetch(`https://localhost:7012/api/reservation/detail/${id}`);
        if (!response.ok) {
          throw new Error("Failed to fetch reservation");
        }
        const data = await response.json();
        setReservation(data);
      } catch (error) {
        console.error("Error fetching reservation:", error);
      }
    };

    fetchReservation();
  }, [id]);

  if (!reservation) {
    return <div>Loading reservation details...</div>;
  }

 return (
  <div className="p-4 max-w-xl mx-auto bg-white rounded-xl shadow-md space-y-4">
    <h2 className="text-xl font-semibold">Reservation Details</h2>

    <div>
      <strong>Reservation ID:</strong> {reservation.reservationId}
    </div>

    <div>
      <strong>Reservation Date:</strong> {reservation.reservationDate}
    </div>

    <div>
      <strong>Customer Name:</strong> {reservation.customerName}
    </div>

    <div>
      <strong>Staff Name:</strong> {reservation.staffName}
    </div>

    <div>
      <strong>Note:</strong> {reservation.note}
    </div>

    <div>
      <strong>Services:</strong>
      {Array.isArray(reservation.services) && reservation.services.length > 0 ? (
        <ul className="list-disc pl-6 mt-2">
          {reservation.services.map((service) => (
            <li key={service.serviceId}>
              <span className="font-medium">{service.serviceName}</span>
            </li>
          ))}
        </ul>
      ) : (
        <p className="text-gray-500 mt-2">No services assigned.</p>
      )}
    </div>
  </div>
);
}

export default ReservationDetail;
