import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const ServiceDetail = () => {
  const { id } = useParams();
  const [service, setService] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/service/detail/${id}`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch service");
        return res.json();
      })
      .then((data) => {
        setService(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Fetch error:", err);
        alert("Error loading service");
        setLoading(false);
      });
  }, [id]);

  if (loading) return <p>Loading...</p>;
  if (!service) return <p>Service not found</p>;

  return (
    <div style={{ maxWidth: "800px", margin: "0 auto" }}>
      <h2>Service Detail #{service.serviceId}</h2>
      <img
        src={`/images/${service.image}`}
        alt={service.serviceName}
        style={{ maxWidth: "300px", marginBottom: "20px" }}
      />
      <p><strong>Name:</strong> {service.serviceName}</p>
      <p><strong>Price:</strong> ${service.price}</p>
      <p><strong>Description:</strong> {service.description}</p>
      <p><strong>Duration:</strong> {service.duration || "N/A"}</p>
      <p><strong>Detail:</strong></p>
      <p>{service.detail}</p>
      <p><strong>Status:</strong> {service.status === 1 ? "Active" : "Inactive"}</p>
      <p><strong>Manager:</strong> {service.managerName}</p>
      <button onClick={() => window.location.href = "/service"}>← Back to list</button>
    </div>
  );
};

export default ServiceDetail;
