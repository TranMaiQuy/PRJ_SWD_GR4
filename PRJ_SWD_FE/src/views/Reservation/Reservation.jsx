import React, { useEffect, useState } from "react";

const Reservation = () => {
  const [reservations, setReservations] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchReservations();
  }, []);

  const fetchReservations = () => {
    fetch("https://localhost:7012/api/reservation/list")
      .then((response) => {
        if (!response.ok) throw new Error("Network error");
        return response.json();
      })
      .then((data) => {
        setReservations(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching reservations:", err);
        setLoading(false);
      });
  };

  const handleDelete = (id) => {
    if (!window.confirm("Are you sure you want to delete this reservation?")) return;

    fetch(`https://localhost:7012/api/reservation/delete/${id}`, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) throw new Error("Failed to delete");
        fetchReservations(); // Reload list
      })
      .catch((err) => console.error("Delete error:", err));
  };

 const handleDetail = (id) => {
    // 👉 Điều hướng đến trang ReservationDetail
    window.location.href = `/reservation/detail/${id}`;
  };

  const handleEdit = (id) => {
    window.location.href = `/reservation/edit/${id}`;
  };

  const handleCreate = () => {
    alert("Redirect to create reservation form");
    window.location.href = "/reservation/create";
  };

  if (loading) return <p>Loading...</p>;

  return (
    <div>
      <h2>Reservation List</h2>
      <button onClick={handleCreate}>+ Create Reservation</button>
      <br /><br />
      <table border="1" cellPadding="8" style={{ borderCollapse: "collapse" }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Customer ID</th>
            <th>Staff ID</th>
            <th>Created Date</th>
            <th>Reservation Date</th>
            <th>Status</th>
            <th>Note</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {reservations.map((r) => (
            <tr key={r.reservationId}>
              <td>{r.reservationId}</td>
              <td>{r.customerId}</td>
              <td>{r.staffId}</td>
              <td>{r.createdDate}</td>
              <td>{r.reservationDate}</td>
              <td>{r.status}</td>
              <td>{r.note}</td>
              <td>
                <button onClick={() => handleDetail(r.reservationId)}>Detail</button>{" "}
                <button onClick={() => handleEdit(r.reservationId)}>Edit</button>{" "}
                <button onClick={() => handleDelete(r.reservationId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Reservation;
