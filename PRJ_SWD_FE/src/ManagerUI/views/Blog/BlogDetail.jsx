import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

const BlogDetail = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [blog, setBlog] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    console.log('Blog Detail ID:', id);
    fetch(`https://localhost:7012/api/blog/detail?id=${id}`)
      .then((response) => {
        if (!response.ok) {
          throw new Error("Blog not found");
        }
        return response.json();
      })
      .then((data) => setBlog(data))
      .catch((err) => setError(err.message));
  }, [id]);

  if (error) return <p style={{ color: "red" }}>{error}</p>;
  if (!blog) return <p>Loading...</p>;

  return (
    <div style={{ padding: "20px" }}>
      <button onClick={() => navigate(-1)} style={{ marginBottom: "15px" }}>
        ⬅ Back
      </button>

      <h2>{blog.title}</h2>
      <p><strong>Description:</strong> {blog.description}</p>
      <img
        src={
          blog.image?.startsWith("https")
            ? blog.image
            : `https://localhost:7012/images/${blog.image}`
        }
        alt={blog.title}
        style={{ maxWidth: "100%", height: "auto", margin: "10px 0" }}
      />
      <p>{blog.content}</p>
      <p><strong>Created Date:</strong> {blog.createdDate}</p>
      <p><strong>Person ID:</strong> {blog.personId}</p>
      <p><strong>Category ID:</strong> {blog.categoryId}</p>
    </div>
  );
};

export default BlogDetail;
