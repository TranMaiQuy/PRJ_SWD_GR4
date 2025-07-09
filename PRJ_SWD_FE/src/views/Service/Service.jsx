import React, { useEffect, useState } from "react";

const Service = () => {
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("https://localhost:7012/api/service/list")
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch services");
        return res.json();
      })
      .then((data) => {
        setServices(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Fetch error:", err);
        setLoading(false);
      });
  });

  const handleCreate = () => {
    alert("Redirect to create service form");
    window.location.href = "/service/create";
  };

  const handleEdit = (id) => {
    window.location.href = `/service/edit/${id}`;
  };

  const handleDetail = (id) => {
    window.location.href = `/service/detail/${id}`;
  };

  const handleDelete = (id) => {
    if (!window.confirm("Are you sure you want to delete this service?")) return;

    fetch(`https://localhost:7012/api/service/${id}`, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) throw new Error("Failed to delete service");
        setServices((prev) => prev.filter((s) => s.serviceId !== id));
      })
      .catch((err) => console.error("Delete error:", err));
  };

  if (loading) return <p>Loading...</p>;

  return (
    <div>
      <h2>Service List</h2>
      <button onClick={handleCreate}>+ Create Service</button>
      <br /><br />
      <table border="1" cellPadding="8" style={{ borderCollapse: "collapse", width: "100%" }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Price</th>
            <th>Manager</th>
            <th>Duration</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {services.map((s) => (
            <tr key={s.serviceId}>
              <td>{s.serviceId}</td>
              <td>{s.serviceName}</td>
              <td>{s.price}</td>
              <td>{s.managerName}</td>
              <td>{s.duration}</td>
              <td>{s.status === 1 ? "Active" : "Inactive"}</td>
              <td>
                <button onClick={() => handleDetail(s.serviceId)}>Detail</button>{" "}
                <button onClick={() => handleEdit(s.serviceId)}>Edit</button>{" "}
                <button onClick={() => handleDelete(s.serviceId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Service;
