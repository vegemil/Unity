// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33092,y:32574,varname:node_4013,prsc:2|diff-7598-RGB,normal-2004-RGB,emission-5767-OUT;n:type:ShaderForge.SFN_Tex2d,id:7598,x:32912,y:32574,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_Texture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0f83c88893812674fb27a67cc3d624d9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5767,x:32831,y:32736,varname:node_5767,prsc:2|A-3466-OUT,B-1612-OUT;n:type:ShaderForge.SFN_Multiply,id:3466,x:32743,y:32623,varname:node_3466,prsc:2|A-7598-RGB,B-1348-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1612,x:32798,y:32910,ptovrint:False,ptlb:Rim Light Intensity,ptin:_RimLightIntensity,varname:_RimLightIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Multiply,id:1348,x:32565,y:32623,varname:node_1348,prsc:2|A-2991-RGB,B-3065-OUT;n:type:ShaderForge.SFN_Color,id:2991,x:32363,y:32533,ptovrint:False,ptlb:Rim Light Color,ptin:_RimLightColor,varname:_RimLightColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:3065,x:32539,y:32798,varname:node_3065,prsc:2|A-9019-OUT,B-8092-OUT;n:type:ShaderForge.SFN_Power,id:9019,x:32369,y:32798,varname:node_9019,prsc:2|VAL-1534-OUT,EXP-2689-OUT;n:type:ShaderForge.SFN_Fresnel,id:8092,x:32417,y:32937,varname:node_8092,prsc:2|NRM-2004-RGB,EXP-2689-OUT;n:type:ShaderForge.SFN_Tex2d,id:2004,x:32647,y:32981,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:_Normal,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54a57c962fa43e14e9c13ad64e22b5ee,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Vector1,id:2689,x:32172,y:32899,varname:node_2689,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:1534,x:32172,y:32751,varname:node_1534,prsc:2|IN-1920-OUT;n:type:ShaderForge.SFN_Dot,id:1920,x:32131,y:32582,varname:node_1920,prsc:2,dt:0|A-5458-XYZ,B-9057-XYZ;n:type:ShaderForge.SFN_Transform,id:9057,x:32013,y:32751,varname:node_9057,prsc:2,tffrom:2,tfto:0|IN-3270-OUT;n:type:ShaderForge.SFN_Vector3,id:3270,x:31992,y:32978,varname:node_3270,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_ViewPosition,id:5458,x:31831,y:32618,varname:node_5458,prsc:2;proporder:7598-1612-2991-2004;pass:END;sub:END;*/

Shader "Shader Forge/Rimlight1" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _RimLightIntensity ("Rim Light Intensity", Float ) = 10
        _RimLightColor ("Rim Light Color", Color) = (1,0,0,1)
        _Normal ("Normal", 2D) = "black" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _RimLightIntensity;
            uniform float4 _RimLightColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = _Texture_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_2689 = 5.0;
                float3 emissive = ((_Texture_var.rgb*(_RimLightColor.rgb*(pow(saturate(dot(_WorldSpaceCameraPos,mul( float3(0,0,1), tangentTransform ).xyz.rgb)),node_2689)*pow(1.0-max(0,dot(_Normal_var.rgb, viewDirection)),node_2689))))*_RimLightIntensity);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _RimLightIntensity;
            uniform float4 _RimLightColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = _Texture_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
